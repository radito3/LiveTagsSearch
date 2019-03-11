export class FileModel {
  name: string;
  icon: string;
  type: string;
  content: string | null; //this is unneeded in requests that need a list of files
  //only when there is a request for a single file does this field is needed
  tags: string[];

  public isRenderable(): boolean {
    return this.isText() || this.isImg();
  }

  public isText(): boolean {
    return this.type.startsWith('text')
  }

  public isImg(): boolean {
    return this.type.startsWith('image');
  }
}


//should make another class that contains full info on the model
/*the first class needs to be reworked only to include:
  name,
  icon,
  tagsCount

*/
