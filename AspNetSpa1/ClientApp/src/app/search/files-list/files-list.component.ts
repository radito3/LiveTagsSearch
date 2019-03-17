import { FileModel }                from "../file-model";
import { HttpClient, HttpParams }   from "@angular/common/http";
import { Component, Inject, Input } from "@angular/core";
import { SearchComponent }          from "../search.component";

@Component({
  selector: 'files-list',
  templateUrl: './files-list.component.html'
})
export class FilesListComponent {
  @Input() public searchType: string;
  @Input() public searchValue: string;
  @Input() public orderProp: string;
  @Input() public route: string;
  public files: FileModel[];

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              @Inject(SearchComponent) comp: SearchComponent) {
    http.get<FileModel[]>(baseUrl + 'api/Search/Files',
      { params: new HttpParams().append('route', comp.path)})
      .subscribe(result => {
        this.files = result;
      }, error => console.error(error));
  }
}
