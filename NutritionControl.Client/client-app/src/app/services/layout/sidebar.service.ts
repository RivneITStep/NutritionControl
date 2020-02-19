import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  links = [
    {
      routerLink: "news",
      text: "News"
    },
    {
      routerLink: "products",
      text: "Products"
    },
    {
      routerLink: "calculators",
      text: "Calculators"
    },
    {
      routerLink: "",
      text: "Fav. Prod"
    },
    {
      routerLink: "",
      text: "Fav. Recipes"
    },
    {
      routerLink: "",
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
