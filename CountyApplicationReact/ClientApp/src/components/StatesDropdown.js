import React, {Component} from "react";
export class StatesDropdown extends Component {
    static displayName = StatesDropdown.name;
    constructor() {
        this.state = {stateNames: [], selectedStateName: ''};
        fetch('api/State/GetStateNames')
        .then(response => response.json())
        .then(data => {this.setState({stateNames: data})});
    }

    handleStateChange(event) {
        this.setState({selectedStateName: event.target.value});
    }

    handleSubmit(event) {
        fetch('api/State/SetSelectedState', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(this.state.selectedStateName)
        });
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit.bind(this)}>
                <p>Select a State: </p>
                <select id="statesDropdownControl" value={this.state.selectedStateName} onChange={this.handleStateChange.bind(this)}>
                    {this.state.stateNames.map((stateName, index) => (
                        <option key={index} value={stateName}>{stateName}</option>
                    ))}
                </select>
                <button type="submit">Submit</button>
            </form>
        );
    }
}