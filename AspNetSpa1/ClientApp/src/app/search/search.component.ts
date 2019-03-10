import {Component, Inject, Input} from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { FileModel } from "./file-model";

@Component({
  selector: 'search-root',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public path: string = './';
  public _searchType: string = 'name';
  private str: string | undefined;

  public dirBack() {
    this.str = this.path.match(new RegExp('\\.\\/(\\.\\.\\/|[^\\/\\.]+\\/)*')).pop();
    this.path += this.str == undefined || this.str == '../' ?
      '../' : this.path.substring(0, this.path.substr(0, this.path.length - 1).lastIndexOf('/'));
  }

  // @Input
  set searchType(searchType: string) {
    this._searchType = searchType;
  }

  get searchType() {
    return this._searchType;
  }
}
