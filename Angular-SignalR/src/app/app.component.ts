import { Component, OnInit } from '@angular/core';
import { SignalrService } from './services/signalr.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor(public signalRService: SignalrService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();   
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:7267/api/chart')
      .subscribe(res => {
        console.log(res);
      })
  }
}