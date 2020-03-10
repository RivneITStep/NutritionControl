import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/services/layout/sidebar.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  links: Array<any>;

  constructor(private sideBarService: SidebarService) { }

  ngOnInit() {
    this.links = this.sideBarService.getSidebarLinks();
  }
}