import {FileModel} from "./file-model";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";
import {debounceTime, distinctUntilChanged} from "rxjs/operators";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class SearchService {

  private res: FileModel[] = [];

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {}

  public getFiles(route: string = './', searchType?: string, searchValue?: string): FileModel[] {
    let params = new HttpParams().append('route', route);

    this.http.get<FileModel[]>(this.baseUrl + 'api/Search/Files',
      { params: searchType == undefined ? params :
          params.append('searchType', searchType)
          .append('value', searchValue) })
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(result => this.res = result,error => console.error(error));
    return this.res;
  }

  public getFile(fileName: string): Observable<FileModel> {
    return this.http.get<FileModel>(this.baseUrl + 'api/Search/File/' + fileName);
  }
}
