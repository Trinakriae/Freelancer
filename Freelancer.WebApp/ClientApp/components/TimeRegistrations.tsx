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

export class TimeRegistrations extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);

        this.state = {
            ...getInitialState()
        };
    }

    public render() {
        return <div>
            <h1>Projects</h1>
        </div>;
    }
}
