import {Component, EventEmitter, Inject, Input, Output, ViewChild} from "@angular/core";
import {FileModel} from "../file-model";
import {HttpClient} from "@angular/common/http";
import {SearchService} from "../search.service";

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html'
})
export class SearchFormComponent {
  public searchString: string;
  public orderProp: string = 'Name';
  @Input() public searchType: string;
  private _searchDir: string;
  @Output() public hasRootDir: EventEmitter<boolean> = new EventEmitter<boolean>();

  @ViewChild('content') public contentModal;
  public content: string;

  public files: FileModel[];

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private service: SearchService) {
    this.service.getFiles()
      .subscribe(next => this.files = next, error => console.error(error));
  }

  @Input()
  set searchDir(searchDir: string) {
    this._searchDir = searchDir;
    this.service.getFiles(this._searchDir)
      .subscribe(next => this.files = next, error => console.error(error));

    this.service.hasRoot(this._searchDir)
      .subscribe(next => this.hasRootDir.emit(next), error => console.error(error));
  }

  get searchDir() {
    return this._searchDir;
  }

  public show(title: string, value: string){
    this.content = value;
    this.contentModal.show();
  }
}
