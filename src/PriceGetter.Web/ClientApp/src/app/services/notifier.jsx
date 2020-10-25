import React from 'react';
import { connect } from "react-redux";
import { useDispatch, useSelector } from 'react-redux';
import { useSnackbar } from 'notistack';
import { hideSnack } from '../redux/actions/notificationsActionCreator';

let displayed = [];

const Notifier = (props) => {
    const dispatch = useDispatch();
    const notifications = props.notifications;
    const { enqueueSnackbar, closeSnackbar } = useSnackbar();

    const storeDisplayed = (id) => {
        displayed = [...displayed, id];
    };

    const removeDisplayed = (id) => {
        displayed = [...displayed.filter(key => id !== key)];
    };

    React.useEffect(() => {
        notifications.forEach(({ key, message, options = {}, dismissed = false }) => {
            if (dismissed) {
                // dismiss snackbar using notistack
                closeSnackbar(key);
                return;
            }

            // do nothing if snackbar is already displayed
            if (displayed.includes(key)) return;

            // display snackbar using notistack
            enqueueSnackbar(message, {
                key,
                ...options,
                onClose: (event, reason, myKey) => {
                    if (options.onClose) {
                        options.onClose(event, reason, myKey);
                    }
                },
                onExited: (event, myKey) => {
                    // remove this snackbar from redux store
                    dispatch(hideSnack(myKey));
                    removeDisplayed(myKey);
                },
            });

            // keep track of snackbars that we've displayed
            storeDisplayed(key);
        });
    }, [notifications, closeSnackbar, enqueueSnackbar, dispatch]);

    return null;
};


const mapStateToProps = (state) => {
    return { notifications: state.notificationsReducer.notifications };
  };
  
  export default connect(mapStateToProps, {})(Notifier);
  