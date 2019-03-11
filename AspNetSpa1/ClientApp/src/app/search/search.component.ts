import { Component } from '@angular/core';

@Component({
  selector: 'search-root',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public path: string = './';
  public _searchType: string = 'Name';

  public dirBack() {
    let str = this.path.match(new RegExp('\\.\\/(\\.\\.\\/|[^\\/\\.]+\\/)*')).pop();
    this.path = str == undefined || str == '../' ?
      this.path + '../' :
      this.path.substring(0, this.path.substr(0, this.path.length - 1).lastIndexOf('/') + 1);
  }

  set searchType(searchType: string) {
    this._searchType = searchType;
  }

  get searchType() {
    return this._searchType;
  }
}
