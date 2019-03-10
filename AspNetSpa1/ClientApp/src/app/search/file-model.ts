export class FileModel {
  name: string;
  icon: string;
  type: string;
  content: string | null;
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
