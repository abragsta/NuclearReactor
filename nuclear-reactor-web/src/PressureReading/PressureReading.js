import React, { Component } from 'react';
import * as signalR from '@aspnet/signalr';

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
            this.setState({pressure: data})
        });

        connection.start();
    }

    render() {
        return (
            <div>Nuclear reactor pressure: {(this.state.pressure * 100).toFixed(0)}%</div>
        );
    }
}


export default PressureReading;