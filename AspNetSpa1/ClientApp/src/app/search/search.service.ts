import {FileModel} from "./file-model";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SearchService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public getFiles(route: string = './', searchType?: string, searchValue?: string): FileModel[] {
    this.http.get<FileModel[]>(this.baseUrl + 'api/Search/Files',
      { params: new HttpParams()
          .append('route', route)
          .append('searchType', searchType)
          .append('value', searchValue) })
      .subscribe(result => {
        return result;
      }, error => console.error(error));
    return;
  }
}
