import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public files: FileModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FileModel[]>(baseUrl + 'api/Search/Files').subscribe(result => {
      this.files = result;
    }, error => console.error(error));
  }

  public renderable(file: FileModel) {
    return file.renderable;
  }

  public hasTags(file: FileModel) {
    return file.tags.length != 0;
  }
}

interface FileModel {
  name: string;
  iconPath: string;
  renderable: boolean;
  tags: string[];
}
