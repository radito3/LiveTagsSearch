import { FileModel } from "../file-model";
import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";

@Component({
  selector: 'files-list',
  templateUrl: './files-list.component.html'
})
export class FilesListComponent {
  //this may not be the data in the class
  public files: FileModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FileModel[]>(baseUrl + 'api/Search/Files').subscribe(result => {
      this.files = result;
    }, error => console.error(error));
  }

  public renderable(file: FileModel) {
    return file.type.startsWith('text') || file.type.startsWith('image');
  }

  public hasTags(file: FileModel) {
    return file.tags.length != 0;
  }
}
