import {FileModel} from "./file-model";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";
import {debounceTime, distinctUntilChanged} from "rxjs/operators";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class SearchService {
  private readonly apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl + 'api/Search/';
  }

  public getFiles(route: string = './', searchType?: string, searchValue?: string): Observable<FileModel[]> {
    let params = new HttpParams().append('route', route);

    if (searchType != undefined) {
      params.append('searchType', searchType);
    }

    if (searchValue != undefined) {
      params.append('value', searchValue);
    }

    return this.http.get<FileModel[]>(this.apiUrl + 'Files', { params: params })
      .pipe(debounceTime(300), distinctUntilChanged());
  }

  public hasRoot(route: string): Observable<boolean> {
    return this.http.get<boolean>(this.apiUrl + 'HasRoot',
      { params: new HttpParams().append('route', route) });
  }

  public folderName(route: string): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl + 'FolderName',
      { params: new HttpParams().append('route', route) });
  }

  public subfolders(route: string): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl + 'Subfolders',
      { params: new HttpParams().append('route', route) });
  }

  public editTags(file: FileModel) {
    let resultJson: Observable<FileModel> = this.http.post<FileModel>(this.apiUrl + 'EditTags', file);

    resultJson.subscribe(value => {}, error => console.log(error));
  }
}
