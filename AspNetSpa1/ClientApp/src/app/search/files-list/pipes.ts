import { Pipe, PipeTransform } from '@angular/core';
import { FileModel } from "../file-model";
import { SearchService } from "../search.service";

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  constructor(private service: SearchService) {}

  transform(value: FileModel[], inputVal: string, searchType: string, searchRoute: string) {
    if (!inputVal) {
      return value;
    }
    //some value down the line is undefined if the search type is tags
    return searchType == 'Name' ?
      value.filter((el: FileModel) => el.name.toLowerCase().indexOf(inputVal.toLowerCase()) > -1) :
      this.service.getFiles(searchRoute, 'tags', inputVal);
  }
}

@Pipe({
  name: 'order'
})
export class OrderPipe implements PipeTransform {

  private fns: Array<OrderFunction> = [
    {orderProp: 'Name', orderFn: (a, b) => a.name.localeCompare(b.name)},
    {orderProp: 'Type', orderFn: (a, b) => a.type == 'dir' && b.type == 'dir' ? 0 : a.type == 'dir' ? 1 : -1},
    {orderProp: 'Tags', orderFn: (a, b) => a.tags.length > b.tags.length ? 1 : -1}
  ];

  private getOrderFn(val: string): OrderFunction {
    return this.fns.find((value, index, obj) => value.orderProp === val);
  }

  transform(value: FileModel[], orderProp: string) {
    return value.sort(this.getOrderFn(orderProp).orderFn);
  }
}

interface OrderFunction {
  orderProp: string
  orderFn: (a: FileModel, b: FileModel) => number
}
