import * as React from 'react';
import * as _ from 'lodash';
import { Checkbox } from 'react-bootstrap';


interface State {
    label: string
    name: string
    disabled: boolean
    isChecked: boolean
}

interface Props {
    label?: string
    name: string
    disabled?: boolean
    isChecked: boolean
    textColor?: string
    onChange: (name: string, isChecked: boolean) => void
}

const getInitialState = () => {

    //Is it worth to keep State?
    const initialState = {
        label: '',
        name: '',
        isChecked: false,
        disabled: true
    };
    return initialState;
}

export class CustomCheckBox extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);

        this.state = getInitialState();

        this.resetState = this.resetState.bind(this);
        this.toggleCheckboxChange = this.toggleCheckboxChange.bind(this);
    }

    resetState() {
        this.setState(getInitialState());
    }

    componentDidMount() {
        const { isChecked, disabled, label, name } = this.props;

        this.setState({
            isChecked: isChecked,
            disabled: disabled || false,
            label: label || '',
            name: name || ''
        });
    }

    componentWillReceiveProps(nextProps: Props) {
        if (!_.isEqual(this.props, nextProps)) {
            this.setState({
                isChecked: nextProps.isChecked,
                disabled: nextProps.disabled || false,
                label: nextProps.label || '',
                name: nextProps.name || ''
            });
        }
    }

    toggleCheckboxChange = () => {
        const { onChange, label, isChecked } = this.props;

        this.setState(({
                isChecked: !isChecked,
            }
        ),
            () => {
                onChange(this.state.name, this.state.isChecked);
            }
        );
    }

    render() {
        const { label, name, isChecked, disabled } = this.state;
        return (
            <Checkbox
                disabled={disabled}
                value={label}
                name={name}
                checked={isChecked}
                onChange={this.toggleCheckboxChange}
                >
                <span className={this.props.textColor ? `text-${this.props.textColor}`: ''}>{label}</span>
            </Checkbox>
        );
    }
}