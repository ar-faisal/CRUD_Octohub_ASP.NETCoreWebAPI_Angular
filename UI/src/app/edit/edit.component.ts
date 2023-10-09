import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

const singleCharacterPattern = /^[a-zA-Z]$/;
const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  employeeId!: number;
  
  employeeForm!: FormGroup;
  fileSelected: boolean = false;
  constructor(private route: ActivatedRoute, public apiService: ApiService, private router: Router, private formBuilder: FormBuilder, private toastr: ToastrService) { }


  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.employeeId = +params['id'];

      this.employeeForm = this.formBuilder.group({
        Eid: [this.employeeId],
        EName: ['', Validators.required],
        Gender: ['', [Validators.required, Validators.pattern(singleCharacterPattern)]],
        Email: ['', [Validators.required, Validators.pattern(emailPattern)]],
        DOB: ['', Validators.required],
        Address: ['', Validators.required],
      });

      this.apiService.getEmployee(this.employeeId).subscribe(
        (data) => {
          
          this.employeeForm.setValue({
            Eid: this.employeeId,
            EName: data.eName,
            Gender: data.gender,
            Email: data.email,
            DOB: data.dob,
            Address: data.address,
          });
        },
        (error) => {
          console.error('Error fetching employee details:', error);
        }
      );
    });
  }

  get urf() {
    return this.employeeForm.controls;
  }


  onSubmit() {
    if (this.employeeForm.valid) {
      const updatedEmployeeData = this.employeeForm.value;

      
      this.apiService.updateEmployee(this.employeeId, updatedEmployeeData).subscribe(
        (response) => {
          this.toastr.success('Employee updated successfully!', 'Success');
          this.router.navigate(['/employees']);
          
        },
        (error) => {
          console.error('Error updating employee:', error);
        }
      );
    }
  }

}
