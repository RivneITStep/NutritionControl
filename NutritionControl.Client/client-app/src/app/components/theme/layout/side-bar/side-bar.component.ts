import { Component, OnInit, Input } from '@angular/core';
import { SidebarService } from 'src/app/services/layout/sidebar.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  @Input() links: Array<any>;

  constructor(private sidebarService: SidebarService) { }

  ngOnInit() { }
}