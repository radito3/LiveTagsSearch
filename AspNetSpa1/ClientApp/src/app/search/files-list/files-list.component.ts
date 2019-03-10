import { FileModel } from "../file-model";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Component, Inject, Input } from "@angular/core";

@Component({
  selector: 'files-list',
  templateUrl: './files-list.component.html'
})
export class FilesListComponent {
  //this data needs to be injected from parent
  public nameToSearch?: string;
  @Inject('tags') public tagsToSearch?: string; //don't know whether to use inject or input
  @Input() public route: string; //probably input

  public files: FileModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FileModel[]>(baseUrl + 'api/Search/Files',
      { params: new HttpParams()
          .append('route', this.route)
          .append('value', this.nameToSearch || this.tagsToSearch) })
      .subscribe(result => {
        this.files = result;
      }, error => console.error(error));
  }
}
