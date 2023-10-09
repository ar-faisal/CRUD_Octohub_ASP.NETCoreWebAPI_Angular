import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  employeeId!: number;
  employees: any[] = [];
  constructor(private route: ActivatedRoute, public apiService: ApiService, private router: Router, private toastr: ToastrService) { }


  


          ngOnInit() {
            this.route.params.subscribe((params) => {
              this.employeeId = +params['id'];

              this.apiService.getEmployee(this.employeeId).subscribe(
                (data) => {
                  this.employees.push(data);
                  

                },
                (error) => {
                  console.error('Error fetching employee details:', error);
                }
              );
            });
          }



  deleteEmployee() {
    this.apiService.deleteEmployee(this.employeeId).subscribe(
      () => {
        this.toastr.success('Employee deleted successfully!', 'Deleted');
        this.router.navigate(['/employees']);
      },
      (error) => {
        
        console.error('Error deleting employee:', error);
      }
    );
  }
            

  


}
