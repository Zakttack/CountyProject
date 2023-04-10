import React, {Component} from "react";
export class StatesDropdown extends Component {
    static displayName = StatesDropdown.name;
    constructor(props) {
        super(props);
        this.state = {states: [], selectedState: ''};
    }

    componentDidMount() {
        fetch('/api/states')
        .then(response => response.json())
        .then(data => this.setState({states: data}))
    }

    handleStateChange(event) {
        this.setState({selectedState: event.target.value});
    }

    handleSubmit(event) {
        fetch('/api/selectedstate', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(this.state.selectedState)
        });
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit.bind(this)}>
                <select value={this.state.selectedState} onChange={this.handleStateChange.bind(this)}>
                    {this.state.states.map((state, index) => (
                        <option key={index} value={state}>{state}</option>
                    ))}
                </select>
                <button type="submit">Submit</button>
            </form>
        );
    }
}