import { useState } from "react";
import ToastContainer from "react-bootstrap/ToastContainer";
import Toast from "react-bootstrap/Toast";

type UndoDeletionNotificationProps = {
  message: string;
  proceedDeletion: () => void;
  undoDeletion: () => void;
};

const UndoDeletionNotification = ({
  message,
  proceedDeletion,
  undoDeletion,
}: UndoDeletionNotificationProps) => {
  const [show, setShow] = useState(true);
  const duration = 4000;

  const handleCancelDeletion = () => {
    undoDeletion();
    setShow(false);
  };

  const handleClosure = () => {
    proceedDeletion();
    setShow(false);
  };

  if (!show) {
    return null;
  }

  return (
    <ToastContainer position="bottom-end" className="p-3">
      <Toast
        onClose={handleClosure}
        show={show}
        delay={duration}
        autohide
        className="btn btn-secondary"
      >
        <Toast.Body onClick={handleCancelDeletion}>
          <span className="fs-6">Click here to cancel {message}</span>
        </Toast.Body>
      </Toast>
    </ToastContainer>
  );
};

export default UndoDeletionNotification;
