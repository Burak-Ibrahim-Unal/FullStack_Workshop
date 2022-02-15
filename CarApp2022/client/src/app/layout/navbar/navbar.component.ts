import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  barItems: MenuItem[];
  items: MenuItem[];

  ngOnInit(): void {
    this.barItems = [
      {
        label: 'Araçlar',
        icon: 'pi pi-fw pi-car',
        items: [
          {
            label: 'Arabalar',
            icon: 'pi pi-fw pi-list',
            badge: "5",
            items: [
              {
                label: 'Volvo',
                icon: 'pi pi-fw pi-bookmark',
                items: [
                  {
                    label: 'XS90',
                    icon: 'pi pi-fw pi-bookmark',
                  }
                ]
              },
              {
                label: 'Honda',
                icon: 'pi pi-fw pi-video',
                items: [
                  {
                    label: 'İ30',
                    icon: 'pi pi-fw pi-bookmark',
                  }
                ]
              },
            ]
          },
          {
            label: 'Motorsiklet',
            icon: 'pi pi-fw pi-list',
            badge: "5",
            items: [
              {
                label: 'Volvo',
                icon: 'pi pi-fw pi-bookmark'
              },
              {
                label: 'Honda',
                icon: 'pi pi-fw pi-video'
              },
            ]
          }
        ]
      }
    ];
  }

}
