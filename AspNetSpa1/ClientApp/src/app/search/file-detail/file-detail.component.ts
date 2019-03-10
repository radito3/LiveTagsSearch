import { Component, Inject } from '@angular/core';
import { FileModel } from "../file-model";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'file-detail',
  templateUrl: './file-detail.component.html'
})
export class FileDetailComponent {
  public file: FileModel;
  public content: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public render() {
    this.http.get<string>(this.baseUrl + 'api/Search/file/' + this.file.name)
      .subscribe(result => {
        this.content = this.file.type.startsWith('text') ? result : 'data:image/jpeg;base64,' + result['image'];
      }, error => console.error(error));
  }

}
