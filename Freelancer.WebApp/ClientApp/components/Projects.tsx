import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface State {

}

interface Props extends RouteComponentProps<{}> {

}

const getInitialState = () => {

    const initialState = {
    };
    return initialState;
}


export class Projects extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);

        this.state = {
            ...getInitialState()
        };
    }

    public render() {
       
        return <div>
        </div>;
    }

    private static renderForecastsTable(forecasts: WeatherForecast[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
            {forecasts.map(forecast =>
                <tr key={ forecast.dateFormatted }>
                    <td>{ forecast.dateFormatted }</td>
                    <td>{ forecast.temperatureC }</td>
                    <td>{ forecast.temperatureF }</td>
                    <td>{ forecast.summary }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
