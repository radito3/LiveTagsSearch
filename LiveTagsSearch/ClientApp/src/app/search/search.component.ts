import {Component} from '@angular/core';
import {SearchService} from "./search.service";

@Component({
  selector: 'search-root',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  private _path: string = './';
  private _searchType: string = 'Name';
  public hasRootDir: boolean;
  public folderName: string;
  public subfolders: string[];
  private tempFolder: string;

  constructor(private service: SearchService) {
    this.service.folderName(this._path)
      .subscribe(val => this.folderName = val[0], error => console.log(error));

    this.service.subfolders(this._path)
      .subscribe(val => this.subfolders = val, error => console.log(error));
  }

  dirBack() {
    let str = this._path.match(new RegExp('\\.\\/(\\.\\.\\/|[^\\/\\.]+\\/)*')).pop();
    this._path = str == undefined || str == '../' ?
      this._path + '../' :
      this._path.substring(0, this._path.substr(0, this._path.length - 1).lastIndexOf('/') + 1);

    this.service.folderName(this._path)
      .subscribe(val => this.folderName = val[0], error => console.log(error));

    this.service.subfolders(this._path)
      .subscribe(val => this.subfolders = val, error => console.log(error));
  }

  set searchType(searchType: string) {
    this._searchType = searchType;
  }

  get searchType() {
    return this._searchType;
  }

  listenForRoot(val: boolean) {
    this.hasRootDir = val;
  }

  save(): void {
    if (this.tempFolder != null) {
      this._path += this.tempFolder + '/';
      this.folderName = this.tempFolder;
    }
  }

  cancel(): void {
    this.tempFolder = null;
  }
}
