import {Component} from '@angular/core';
import {SearchService} from "./search.service";
// import {Observable} from "rxjs";

@Component({
  selector: 'search-root',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public _path: string = './';
  public _searchType: string = 'Name';
  public hasRootDir: boolean;
  // public rootDirName: Observable<string>;

  constructor(private service: SearchService) {}

  public dirBack() {
    let str = this._path.match(new RegExp('\\.\\/(\\.\\.\\/|[^\\/\\.]+\\/)*')).pop();
    this._path = str == undefined || str == '../' ?
      this._path + '../' :
      this._path.substring(0, this._path.substr(0, this._path.length - 1).lastIndexOf('/') + 1);

    // this.rootDirName = this.service.getFolderName(this._path);
  }

  set searchType(searchType: string) {
    this._searchType = searchType;
  }

  get searchType() {
    return this._searchType;
  }

  // get folder(): Observable<string> {
  //   return this.service.getFolderName(this._path);
  // }
  //
  // async getFolder(): string {
  //   return await this.service.getFolderNameAsync(this._path);
  // }

  public listenForRoot(val: boolean) {
    this.hasRootDir = val;
  }
}
