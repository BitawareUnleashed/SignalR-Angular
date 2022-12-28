import { Injectable, OnInit } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { ChartModel } from '../_interfaces/chartmodel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public Data: ChartModel[] = [];
  private hubConnection: signalR.HubConnection=new signalR.HubConnectionBuilder()
                    .configureLogging(signalR.LogLevel.Information)
                    .withUrl('https://localhost:7267/chart')
                    .build();


  ngOnInit(){
    this.startConnection();
  }

    public startConnection = () => {
      this.hubConnection = new signalR.HubConnectionBuilder()
                              .withUrl('https://localhost:7267/chart')
                              .build();
      this.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while starting connection: ' + err))
    }
    
    public addTransferChartDataListener = () => {
      this.hubConnection.on('transferdata', (data) => {
        this.Data = data;
        console.log(data);
      });
    }

    public broadcastChartData = () => {
      const data = this.Data.map(m => {
        const temp = {
          data: m.data,
          label: m.label
        }
        return temp;
      });

      this.hubConnection.invoke('broadcastchartdata', data)
      .catch(err => console.error(err));
    }

    public addBroadcastChartDataListener = () => {
      this.hubConnection.on('broadcastchartdata', (data) => {
        //this.bradcastedData = data;
      })
    }
}
