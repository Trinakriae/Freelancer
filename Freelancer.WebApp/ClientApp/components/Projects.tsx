import * as React from 'react';
import { RouteComponentProps } from 'react-router';

import { IProject } from '../interfaces';
import { getUserProjects } from '../services/getData';


interface State {
    projects: IProject[],
    loading: boolean
}

interface Props extends RouteComponentProps<{}> {

}

const getInitialState = () => {

    const initialState = {
        projects: new Array<IProject>(),
        loading: true
    };
    return initialState;
}


export class Projects extends React.Component<Props, State> {
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

    onFetchProjectsSuccess = (response: IProject[]) => {
        this.setState({
            projects: response,
            loading: false
        });
    }

    renderLoading = () => {
        return <p className="loading">Ricerca in corso<span>.</span><span>.</span><span>.</span></p>;
    }

    renderError = () => {
        return <div>Nessun risultato per i criteri impostati</div>;
    }

    renderProjectsTable = (projects: IProject[]) => {
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
                    {_.map(projects, project => {
                        return (<tr key={project.id}>
                            <td>{project.name}</td>
                            <td>{project.description}</td>
                            <td>{`${project.user.name} ${project.user.surname}`}</td>
                            <td>{`${project.customer.name}`}</td>
                        </tr>)
                    })}
                </tbody>
            </table>;
    }


    public render() {
        const { loading, projects } = this.state;

        if (loading) {

        }
        else if (!_.isEmpty(projects)) {
            this.renderProjectsTable(projects);
        }
        else {
            return this.renderError();
        }
        return <div>
        </div>;
    }
}