import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/services/layout/sidebar.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  links: Array<any>;

  constructor(private sidebarService: SidebarService) { }

  ngOnInit() {
    this.links = this.sidebarService.getSidebarLinks();
  }

}
