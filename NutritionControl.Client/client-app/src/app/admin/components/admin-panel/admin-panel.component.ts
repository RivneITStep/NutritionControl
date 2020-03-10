import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/services/layout/sidebar.service';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  links: Array<any>;

  constructor(private sidebarService: SidebarService) { }

  ngOnInit() {
    this.links = this.sidebarService.getSidebarLinks();
  }
}