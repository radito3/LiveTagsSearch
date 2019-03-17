import { Component, Inject, OnInit } from '@angular/core';
import { FileModel } from "../file-model";
import { HttpClient } from "@angular/common/http";
// import {ActivatedRoute, ParamMap, Router} from "@angular/router";
// import {switchMap} from "rxjs/operators";

@Component({
  selector: 'file-detail',
  templateUrl: './file-detail.component.html'
})
export class FileDetailComponent/* implements OnInit */{
  public file: FileModel;
  public content: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string/*,
              private route: ActivatedRoute,
              private router: Router*/) {}

  public render() {
    this.http.get<string>(this.baseUrl + 'api/Search/File/' + this.file.name)
      .subscribe(result => {
        //this will be fixed to be within the new file model
        this.content = result;
        // this.content = this.file.isText() ? result : 'data:image/jpeg;base64,' + result['image'];
      }, error => console.error(error));
  }

  // ngOnInit() {
  //
  // }

}
