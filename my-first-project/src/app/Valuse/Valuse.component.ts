import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({

  // tslint:disable-next-line:component-selector
  selector: 'app-Valuse',
  templateUrl: './Valuse.component.html',
  styleUrls: ['./Valuse.component.css']
})
export class ValuseComponent implements OnInit {
 Valuse: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValuse();
  }
getValuse() {
   this.http.get('https://localhost:5001/WeatherForecast')
    .subscribe(arg => {
      this.Valuse = arg; },
      error => {console.log(error);
      });
}
}
