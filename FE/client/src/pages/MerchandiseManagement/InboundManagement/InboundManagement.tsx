import React, { useEffect, useState } from 'react';
import { createInbound, getAllInbound, updateInbound, deleteInbound } from '../../../api/inbound';
import InboundForm from './InboundForm';
import InboundList from './InboundList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const InboundManagement: React.FC = () => {
    const [inboundList, setInboundList] = useState<any[]>([]);
    const [selectedInbound, setSelectedInbound] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchInboundList();
    }, []);

    useEffect(() => {
        const handleKeyDown = (event: KeyboardEvent) => {
            if (event.key === 'Escape') {
                setShowForm(false);
            }
        };

        document.addEventListener('keydown', handleKeyDown);
        return () => {
            document.removeEventListener('keydown', handleKeyDown);
        };
    }, []);

    const fetchInboundList = async () => {
        const response = await getAllInbound();
        setInboundList(response);
    };

    const handleCreateInbound = async (inbound: Partial<{}>) => {
        await createInbound(inbound);
        fetchInboundList();
        setShowForm(false); // Hide form after creating Inbound
    };

    const handleUpdateInbound = async (inbound: {}) => {
        await updateInbound(inbound);
        fetchInboundList();
        setShowForm(false); // Hide form after updating Inbound
    };

    const handleDeleteInbound = async (id: string) => {
        await deleteInbound(id);
        fetchInboundList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedInbound ? `ID: ${selectedInbound.invoiceEnterId}` : "THÊM HOÁ ĐƠN"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <InboundForm 
                            initialData={selectedInbound || {}} 
                            onSubmit={selectedInbound ? handleUpdateInbound : handleCreateInbound} 
                        />
                    </div>
                </div>
            )}
            <InboundList 
                inboundList={inboundList} 
                onEdit={(inbound: any) => {
                    setSelectedInbound(inbound);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteInbound} 
                setSelectedInbound={setSelectedInbound} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default InboundManagement;
