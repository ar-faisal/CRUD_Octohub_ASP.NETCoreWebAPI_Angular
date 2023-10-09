import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = "http://localhost:5242";
  constructor(private http: HttpClient) { }
  

  

  createEmployee(formData: any) {
    return this.http.post(`${this.apiUrl}/api/employees`, formData);
  }

  getEmployees() {
    return this.http.get(`${this.apiUrl}/api/Employees/GetEmployees`);
  }

  deleteEmployee(employeeId: number) {
    return this.http.delete(`${this.apiUrl}/api/Employees/DeleteEmployee/${employeeId}`);
  }

  getEmployee(employeeId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Employees/GetEmployee/${employeeId}`);
  }
  updateEmployee(employeeId: number, updatedData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/Employees/PutEmployee/${employeeId}`, updatedData);
  }

}
