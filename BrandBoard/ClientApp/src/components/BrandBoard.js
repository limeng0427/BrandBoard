import React, { Component } from 'react';
import _ from 'lodash';

export class BrandBoard extends Component {
    static displayName = BrandBoard.name;

    constructor(props) {
        super(props);
        this.state = { brandBoardItems: [], loading: true };
    }

    componentDidMount() {
        this.populateBrandData();
    }


    static renderBrandBoardTable(data) {
        var grouppedData = _.groupBy(data, (item) => {
            var initialCharCode = item.brandName.toLowerCase().charCodeAt(0);
            if (initialCharCode >= 97 && initialCharCode <= 122) {
                var groupCharCode = 2 * Math.ceil(initialCharCode / 2) - 1 - 32;
                return String.fromCharCode(groupCharCode) + "-" + String.fromCharCode(groupCharCode + 1)
            } else {
                return "Others";
            }
        });
        console.log("grouppedData", grouppedData);
        return (
            <div class="row">
                {Object.keys(grouppedData).map((key, index) =>
                    <div class="col">
                        <h2>{key}</h2>
                        {grouppedData[key].map((item) =>
                            <div class="brand">
                                <img src={item.brandURL} alt={item.brandName} title={item.brandName} />
                            </div>
                        )}
                    </div>
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BrandBoard.renderBrandBoardTable(this.state.brandBoardItems);

        return (
            <div>
                <header><h1>Brands</h1></header>
                {contents}
            </div>
        );
    }

    async populateBrandData() {
        const response = await fetch('api/brandboard');
        const data = await response.json();
        this.setState({ brandBoardItems: data, loading: false });
    }
}
