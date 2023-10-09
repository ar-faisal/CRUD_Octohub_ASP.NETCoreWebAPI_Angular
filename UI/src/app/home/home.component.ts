import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

const singleCharacterPattern = /^[a-zA-Z]$/;
const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'
  ]
})
export class HomeComponent implements OnInit{
  employeeForm!: FormGroup;

  fileSelected: boolean = false;

  



  constructor(private formBuilder: FormBuilder, public apiService: ApiService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      EName: ['', Validators.required],
      Gender: ['', [Validators.required, Validators.pattern(singleCharacterPattern)]],
      Email: ['', [Validators.required, Validators.pattern(emailPattern)]],
      DOB: ['', Validators.required],
      Address: ['', Validators.required]
    });

    
  }

  get urf() {
    return this.employeeForm.controls;
  }



  onSubmit() {
    if (this.employeeForm.valid) {
      
      const formData = this.employeeForm.value;

     
      this.apiService.createEmployee(formData).subscribe(
        (response) => {
          
          console.log('Employee created successfully!', response);

          
          this.employeeForm.reset();
          this.toastr.success('Employee created successfully!', 'Success');

          
          
              
           
        },
        (error) => {
         
          console.error('Error creating employee:', error);
        }
      );
    }
  }

}
