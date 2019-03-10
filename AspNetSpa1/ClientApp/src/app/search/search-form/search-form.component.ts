import { Component } from "@angular/core";

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html'
})
export class SearchFormComponent {
  public searchString: string;
  public searchType: string; //need to get this from the parent component

  //...
}
