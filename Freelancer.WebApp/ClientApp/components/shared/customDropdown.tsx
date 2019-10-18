import * as React from 'react';
import * as _ from 'lodash';
import { Button, Dropdown, MenuItem, OverlayTrigger, Tooltip } from 'react-bootstrap';
import { SelectItem } from '../../classes';


interface State {
    name: string
    selectList: SelectItem[]
    selectedItem: SelectItem
    disabled: boolean
}

interface Props {
    data: SelectItem[]
    name: string
    initialSelectedDataIndex: number
    loading: boolean
    disabled: boolean
    classname?: string

    onChange: (selectedItem: SelectItem, name: string) => void
}

const getInitialState = () => {
    const initialState = {
        name: '',
        selectList: new Array<SelectItem>(),
        selectedItem: new SelectItem('', '', false),
        disabled: true
    };
    return initialState;
}

export class CustomDropdown extends React.Component<Props,State> {
    constructor(props: Props) {
        super(props);

        this.state = getInitialState();

        this.resetState = this.resetState.bind(this);

        this.handleChange = this.handleChange.bind(this);
        this.postHandleChange = this.postHandleChange.bind(this);

        this.createMenuItem = this.createMenuItem.bind(this);
        this.createMenuItems = this.createMenuItems.bind(this);

        this.updateActiveItem = this.updateActiveItem.bind(this);
        this.getSelectedItemByValue = this.getSelectedItemByValue.bind(this);
    }

    resetState() {
        this.setState(getInitialState());
    }

    componentDidMount() {
        this.setState({
            name: this.props.name,
            selectList: this.props.data,
            selectedItem: this.props.data[this.props.initialSelectedDataIndex],
            disabled: this.props.disabled
        });
    }

    componentWillReceiveProps(nextProps: Props) {
        if (!_.isEqual(this.props.data, nextProps.data) ||
            !_.isEqual(this.props.initialSelectedDataIndex, nextProps.initialSelectedDataIndex) ||
            !_.isEqual(this.props.disabled, nextProps.disabled)) {
  
            this.setState({
                name: nextProps.name,
                selectList: nextProps.data,
                selectedItem: nextProps.data[nextProps.initialSelectedDataIndex],
                disabled: nextProps.disabled
            });
        }
    }

    handleChange = (selectedValue: any) => {
        this.setState({
            selectList: this.updateActiveItem(selectedValue),
        },
            () => this.setState({
                selectedItem: this.getSelectedItemByValue(selectedValue)
            },
                () => this.postHandleChange()
            )
        );
    }

    postHandleChange() {
        const { name, selectedItem } = this.state;

        this.props.onChange(selectedItem, name);
    }

    updateActiveItem = (selectedValue: string): SelectItem[] => {
        const { selectList } = this.state;

        let updatedSelectList: SelectItem[] = _.map(selectList, (item) => {
            item.active = item.value ===  selectedValue ? true : false;
            return item;
        });

        return updatedSelectList;
    }

    getSelectedItemByValue = (selectedValue: string): SelectItem => {
        const { selectList } = this.state;

        let selectedItem: SelectItem = new SelectItem('', '', false);

        let i: number = -1;
        let found: boolean = _.some(selectList, (item, index) => {
            i = index;
            return item.value === selectedValue;
        });
        
        if (found) {
            selectedItem = selectList[i];
        }

        return selectedItem;
    }

    createMenuItem = (item: SelectItem) => {
        return (
            <MenuItem
                bsClass={this.props.classname}
                key={item.value}
                eventKey={item.value}
                active={item.active}
            >
                {item.label}
            </MenuItem>);
    }

    createMenuItems() {
        const { selectList } = this.state;

        return selectList.map(this.createMenuItem);
    }

    renderLoading() {
        return (
            <Button><p className="loading"><span>.</span><span>.</span><span>.</span></p></Button>
               
        );
    }

    renderError() {
        return <div>An error occured.</div>;
    }

    renderToolTip() {
        const { selectedItem } = this.state;
        return (
            <Tooltip id="tooltip">
                <strong>{selectedItem.label}</strong>
            </Tooltip>
        );
    }

    render() {
        const { name, selectedItem, disabled } = this.state;

        if (this.props.loading) {
            return this.renderLoading();
        } else if (!this.props.loading) {
            
            return (
                <OverlayTrigger
                    placement="top"
                    overlay={this.renderToolTip()}>
                <Dropdown 
                    value={selectedItem.value}
                    id={name}
                    onSelect={this.handleChange}
                    disabled={disabled}
                >
                    <Dropdown.Toggle>
                            {selectedItem.label.toString().substring(0, 20) + (selectedItem.label.toString().length > 20 ? '...' : '')}
                        </Dropdown.Toggle>
                    <Dropdown.Menu>
                        {this.createMenuItems()}
                    </Dropdown.Menu>
                    </Dropdown>
                </OverlayTrigger>
            );
        }
        else {
            return this.renderError();
        }
    }
}