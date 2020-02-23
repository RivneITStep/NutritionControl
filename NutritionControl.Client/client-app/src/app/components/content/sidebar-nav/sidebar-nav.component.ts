import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar-nav',
  templateUrl: './sidebar-nav.component.html',
  styleUrls: ['./sidebar-nav.component.css']
})
export class SidebarNavComponent implements OnInit {

  @Input() categories: Array<string>;
  selectedCategory: string = ""; 

  constructor() { }

  ngOnInit() {
    
  }

  scrollToCategory(categoryName: string) {
    //mda
    let el = document.getElementById(categoryName);
    var rect = el.getBoundingClientRect();
    window.scrollTo({top: rect.top + document.documentElement.scrollTop - 90,behavior:"smooth"})

    this.selectedCategory = categoryName;
  }
}