import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  links = [
    {
      routerLink: "news",
      text: "News",
      icon: "fas fa-newspaper pb-1"
    },
    {
      routerLink: "products",
      text: "Products",
      icon: "fas fa-utensils pb-1"
    },
    {
      routerLink: "calculator",
      text: "Calculator",
      icon: "fas fa-calculator pb-1"
    },
    {
      routerLink: "",
      text: "Favourite Products",
      icon: "fas fa-star pb-1"
    },
    {
      routerLink: "",
      text: "Favourite Receipts",
      icon: "fas fa-star pb-1"
    },
    {
      routerLink: "receipts",
      text: "Receipts",
      icon: "fas fa-clipboard-list pb-1"
    },
    {
      routerLink: "diary",
      text: "Diary",
      icon: "fas fa-book pb-1"
    }
  ]

  constructor() { }

  getSidebarLinks(): Array<any> {
    return this.links;
  }

}
