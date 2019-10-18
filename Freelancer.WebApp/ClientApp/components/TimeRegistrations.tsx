import * as React from 'react';
import { RouteComponentProps } from 'react-router';

import { IAllocatedTime } from '../interfaces';
import { getUserProjects } from '../services/getData';


interface State {
    allocatedTimes: IAllocatedTime[],
    loading: boolean
}

interface Props extends RouteComponentProps<{}> {

}

const getInitialState = () => {

    const initialState = {
        allocatedTimes: new Array<IAllocatedTime>(),
        loading: true
    };
    return initialState;
}


export class TimeRegistrations extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);

        this.state = {
            ...getInitialState()
        };

        this.fetchProjects = this.fetchProjects.bind(this);
        this.onFetchProjectsSuccess = this.onFetchProjectsSuccess.bind(this);
        this.onError = this.onError.bind(this);
    }

    componentDidMount() {
        this.fetchProjects();
    }

    componentWillReceiveProps(nextProps: Props) {
        if (this.props != nextProps) {
            this.fetchProjects();
        }
    }

    onError(xhr: JQuery.jqXHR, status: JQuery.Ajax.ErrorTextStatus) {
        this.setState(
            {
                loading: false
            });
    }

    fetchProjects = () => {
        getUserProjects(1, this.onFetchProjectsSuccess, this.onError);
    }

    onFetchProjectsSuccess = (response: IAllocatedTime[]) => {
        this.setState({
            allocatedTimes: response,
            loading: false
        });
    }

    renderLoading = () => {
        return <p className="loading">Ricerca in corso<span>.</span><span>.</span><span>.</span></p>;
    }

    renderError = () => {
        return <div>Nessun risultato per i criteri impostati</div>;
    }

    renderAllocatedTimesTable = (allocatedTimes: IAllocatedTime[]) => {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>User</th>
                    <th>Customer</th>
                </tr>
            </thead>
            <tbody>
                {_.map(allocatedTimes, allocatedTime => {
                    return (<tr key={allocatedTime.id}>
                        <td>{allocatedTime.name}</td>
                        <td>{allocatedTime.description}</td>
                        <td>{`${allocatedTime.user.name} ${allocatedTime.user.surname}`}</td>
                        <td>{`${allocatedTime.customer.name}`}</td>
                    </tr>)
                })}
            </tbody>
        </table>;
    }


    public render() {
        const { loading, allocatedTimes } = this.state;

        if (loading) {

        }
        else if (!_.isEmpty(allocatedTimes)) {
            this.renderAllocatedTimesTable(allocatedTimes);
        }
        else {
            return this.renderError();
        }
        return <div>
        </div>;
    }
}