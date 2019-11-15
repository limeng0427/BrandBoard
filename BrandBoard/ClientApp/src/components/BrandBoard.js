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
        console.log("grouppedData", data);
        
        return (
            <div class="row">
                {data.map((group) =>
                    <div class="col">
                        <h2>{group.groupName}</h2>
                        {group.items.map((item) =>
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
