import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styles: [
  ]
})

export class EmployeesComponent implements OnInit{
  employees: any[] = [];
  pageSize: number = 5;
  currentPage: number = 1;

  constructor(public apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getEmployees().subscribe((data: any) => {
      this.employees = data;
    });
  }








}





