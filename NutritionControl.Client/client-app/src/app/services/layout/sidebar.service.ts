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
      routerLink: "diary",
      text: "Diary"
    },
    {
      routerLink: "",
      text: "Diet"
    }
  ]

  constructor() { }

  getSidebarLinks(): Array<any> {
    return this.links;
  }

}
