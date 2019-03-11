import {Component, Input} from "@angular/core";

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html'
})
export class SearchFormComponent {
  public searchString: string;
  @Input() public searchType: string;
  @Input() public searchDir: string;
}
