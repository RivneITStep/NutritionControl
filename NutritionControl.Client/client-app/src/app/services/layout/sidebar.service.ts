import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  links = [
    {
      link: "",
      text: "News"
    },
    {
      link: "",
      text: "Products"
    },
    {
      link: "",
      text: "Calculators"
    },
    {
      link: "",
      text: "Fav. Prod"
    },
    {
      link: "",
      text: "Fav. Recipes"
    },
    {
      link: "",
      text: "Recipes"
    },
    {
      link: "",
      text: "Diary"
    },
    {
      link: "",
      text: "Diet"
    }
  ]

  constructor() { }

  getSidebarLinks(): Array<any> {
    return this.links;
  }

}
