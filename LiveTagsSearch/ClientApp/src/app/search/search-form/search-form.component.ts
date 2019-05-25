import {Component, EventEmitter, Inject, Input, Output, ViewChild} from "@angular/core";
import {FileModel} from "../file-model";
import {HttpClient} from "@angular/common/http";
import {SearchService} from "../search.service";

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html'
})
export class SearchFormComponent {
  public searchString: string;
  public orderProp: string = 'Name';
  @Input() public searchType: string;
  private _searchDir: string;
  @Output() public hasRootDir: EventEmitter<boolean> = new EventEmitter<boolean>();

  @ViewChild('modal') public contentModal;
  public fileType: string;
  public modalTitle: string;
  public modalType: string;
  public contentToDisplay: string | string[];
  private currentFile: FileModel;
  private tagString: string;

  public files: FileModel[];

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private service: SearchService) {
    this.service.getFiles()
      .subscribe(next => this.files = next, error => console.error(error));
  }

  @Input()
  set searchDir(searchDir: string) {
    this._searchDir = searchDir;
    this.service.getFiles(this._searchDir)
      .subscribe(next => this.files = next, error => console.error(error));

    this.service.hasRoot(this._searchDir)
      .subscribe(next => this.hasRootDir.emit(next), error => console.error(error));
  }

  get searchDir() {
    return this._searchDir;
  }

  public showContent(file: FileModel) {
    this.modalType = 'content';
    this.modalTitle = file.name;
    this.fileType = file.type;
    this.contentToDisplay = file.content;
    this.contentModal.show();
  }

  public showTags(file: FileModel) {
    this.modalType = 'tags';
    this.modalTitle = "Edit tags for " + file.name + ":";
    this.contentToDisplay = file.tags.map(tag => {
      //this remapping shouldn't be needed
      if (tag.indexOf("[") != -1) {
        tag = tag.substring(1);
      }
      if (tag.indexOf("]") != -1) {
        tag = tag.substring(0, tag.length - 1);
      }
      if (tag.indexOf("\"") != -1) {
        tag = tag.substring(tag.indexOf("\"") + 1, tag.lastIndexOf("\""));
      }
      return tag;
    });
    this.currentFile = file;
    this.contentModal.show();
  }

  public addTag1() {
    if (this.tagString != "") {
      (<string[]>this.contentToDisplay).push(this.tagString);
    }
    this.tagString = "";
  }

  public deleteTag(tag: string) {
    this.contentToDisplay = (<string[]>this.contentToDisplay).filter(val => !(val.localeCompare(tag) == 0));
  }

  public editTags() {
    let mismatch = this.currentFile.tags.sort().toString() == (<string[]>this.contentToDisplay).sort().toString();

    if (mismatch || this.currentFile.tags.length != (<string[]>this.contentToDisplay).length) {
      this.currentFile.tags = (<string[]>this.contentToDisplay);
      this.service.editTags(this.currentFile);
    }
  }
}
