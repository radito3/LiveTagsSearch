export class FileModel {
  name: string;
  iconPath: string;
  type: string;
  content: string | null;
  tags: string[];
  renderable: boolean;

  //would be better if this is a property
  // public isRenderable(): boolean {
  //   return this.isText() || this.isImg() || this.type.endsWith("json") || this.type.endsWith("xml");
  // }
  //
  // public isText(): boolean {
  //   return this.type.startsWith('text')
  // }
  //
  // public isImg(): boolean {
  //   return this.type.startsWith('image');
  // }
}
