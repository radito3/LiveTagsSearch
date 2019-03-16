import { Pipe, PipeTransform } from '@angular/core';
import { FileModel } from "../file-model";

@Pipe({
  name: 'FilterPipe'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, input: string) {
    return !input ? value :
      value.filter((el: FileModel) => el.name.toLowerCase().indexOf(input.toLowerCase()) > -1);
  }
}

@Pipe({
  name: 'OrderPipe'
})
export class OrderPipe implements PipeTransform {

  private orderMap;

  transform(value: FileModel[], orderProp: string) {
    //sort them by the order property
    return value.sort((a: FileModel, b: FileModel) => a.name.localeCompare(b.name));
  }
}
