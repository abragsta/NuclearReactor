import React, { Component } from 'react';
import * as signalR from '@aspnet/signalr';
import { Line } from 'rc-progress';

class PressureReading extends Component {
    state = {
        pressure: 0
    }

    componentDidMount = () => {
        let connection = new signalR.HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_BASE_URL + "pressurereading")
            .build();

        connection.on("pressureUpdate", data => {
            console.log(data);
            this.setState({ pressure: (data * 100).toFixed(0) })
        });

        connection.start();
    }

    render() {
        return (
            <div>
                <div>Nuclear reactor pressure: {this.state.pressure}%</div>
                <Line percent={this.state.pressure} strokeWidth="4" strokeColor="#4286f4" />
            </div>
        );
    }
}


export default PressureReading;