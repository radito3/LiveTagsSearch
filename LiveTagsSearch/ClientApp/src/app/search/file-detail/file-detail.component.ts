import { Component, Inject, OnInit } from '@angular/core';
import { FileModel } from "../file-model";
import { HttpClient } from "@angular/common/http";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {Location} from "@angular/common";
import {Observable} from "rxjs";
import {switchMap} from "rxjs/operators";
import {SearchService} from "../search.service";

@Component({
  selector: 'file-detail',
  templateUrl: './file-detail.component.html'
})
export class FileDetailComponent implements OnInit {

  public file: Observable<FileModel>;
  public content: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private route: ActivatedRoute,
              private router: Router,
              private location: Location,
              private service: SearchService) {}

  public back() {
    this.location.back();
  }

  public render() {
    //this will be reworked
    console.log("rendering...");
    // this.http.get<string>(this.baseUrl + 'api/Search/File/' + this.file.name)
    //   .subscribe(result => {
    //     //this will be fixed to be within the new file model
    //     this.content = result;
    //     // this.content = this.file.isText() ? result : 'data:image/jpeg;base64,' + result['image'];
    //   }, error => console.error(error));
  }

  ngOnInit() {
    // this.file = this.route.paramMap.pipe(
    //   switchMap((params: ParamMap) => this.service.getFile(params.get('name')))
    // );
    let name: string = 'bin';
    this.route.url.subscribe(res => name = res.pop().toString(), err => console.log(err));
    this.file = this.service.getFile(name);
  }

  public isRenderable(file: FileModel): boolean {
    return file.isRenderable();
  }
}
