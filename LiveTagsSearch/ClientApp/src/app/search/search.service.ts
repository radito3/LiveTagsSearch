import {FileModel} from "./file-model";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";
import {debounceTime, distinctUntilChanged} from "rxjs/operators";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class SearchService {

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {}

  public getFiles(route: string = './', searchType?: string, searchValue?: string): Observable<FileModel[]> {
    let params = new HttpParams().append('route', route);

    if (searchType != undefined) {
      params.append('searchType', searchType);
    }

    if (searchValue != undefined) {
      params.append('value', searchValue);
    }

    return this.http.get<FileModel[]>(this.baseUrl + 'api/Search/Files', { params: params })
      .pipe(debounceTime(300), distinctUntilChanged());
  }

  public hasRoot(route: string): Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl + 'api/Search/HasRoot',
      { params: new HttpParams().append('route', route) });
  }

  public folderName(route: string): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + 'api/Search/FolderName',
      { params: new HttpParams().append('route', route) });
  }

  public subfolders(route: string): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + 'api/Search/Subfolders',
      { params: new HttpParams().append('route', route) });
  }

  //this should not be needed
  public getFile(fileName: string): Observable<FileModel> {
    return this.http.get<FileModel>(this.baseUrl + 'api/Search/File/' + fileName);
  }
}
