import React, { useState, useEffect } from 'react';
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

const PolicyView = () => {
  const [gridApi, setGridApi] = useState(null);
  const [gridColumnApi, setGridColumnApi] = useState(null);

  const [rowData, setRowData] = useState([
      { policyId: 1, propertyId: 1, address: '6821 Defiance Dr, Huntington Beach, CA 92647', insuredName: 'Ferdinand Espiritu', status: 'Quote', coverages: 'Coverage1, Coverage2', rating: 117290 },
      { policyId: 2, propertyId: 2, address: '555 Main St, New York, New York 45673', insuredName: 'John Doe', status: 'Issued', coverages: 'Coverage4, Coverage5', rating: 50070 }
  ]);
  return(
    <>
      <div className="ag-theme-alpine" style={{ height: 400 }}>
          <AgGridReact
              rowData={rowData}>
              <AgGridColumn field="policyId" width="90"></AgGridColumn>
              <AgGridColumn field="propertyId" width="110"></AgGridColumn>
              <AgGridColumn field="address" width="400"></AgGridColumn>
              <AgGridColumn field="insuredName" width="150"></AgGridColumn>
              <AgGridColumn field="status" width="90"></AgGridColumn>
              <AgGridColumn field="coverages" width="200"></AgGridColumn>
              <AgGridColumn field="rating" width="100"></AgGridColumn>
          </AgGridReact>
      </div>
    </>
  )
}

export default PolicyView;